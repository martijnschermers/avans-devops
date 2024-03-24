using Domain.BacklogItems;
using Domain.Git;
using Domain.Notifications;
using NSubstitute;

namespace Domain.Tests
{
  public class GitTests
  {
    [Fact]
    public void CanCreateRepoWithBranchesAndCommits()
    {
      // Arrange
      var repo = new Repository("My repository", "C#");
      var branch1 = new Branch("Main", repo);
      var branch2 = new Branch("Feature 1", repo);
      var branch3 = new Branch("Feature 2", repo);
      var commit1 = new Commit("Initial commit");
      var commit2 = new Commit("Add feature 1");
      var commit3 = new Commit("Add feature 2");

      // Act
      repo.AddBranch(branch1);
      repo.AddBranch(branch2);
      repo.AddBranch(branch3);
      branch1.AddCommit(commit1);
      branch2.AddCommit(commit2);
      branch3.AddCommit(commit3);

      // Assert
      Assert.Equal(4, repo.Branches.Count);
      Assert.Single(branch1.Commits);
      Assert.Single(branch2.Commits);
      Assert.Single(branch3.Commits);
    }

    [Fact]
    public void AddBranchToABacklogItem()
    {
      // Arrange
      var notificationService = Substitute.For<INotificationService>();
      var backlogItem = new BacklogItem("New feature", "As a user, I want to be able to do something", 5, notificationService);
      var repo = new Repository("My repository", "C#");
      var branch = new Branch("Feature 1", repo);

      // Act
      backlogItem.AddBranch(branch);

      // Assert
      Assert.Equal(branch, backlogItem.Branch);
    }

    [Fact]
    public void CanEditCommit()
    {
      // Arrange
      var commit = new Commit("Initial commit");

      // Act
      commit.EditCommit("Add feature 1");

      // Assert
      Assert.Equal("Add feature 1", commit.Message);
    }
  }
}